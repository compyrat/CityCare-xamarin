using System;
using System.Collections.Generic;


using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Android.Graphics;


using Android.Gms.Maps;
using Android.Gms.Maps.Model;

using Android.Locations;

using System.Globalization;
using System.Timers;
using Android.Views;

namespace Proyecto_Final___Xamarin_Ver.Incidences
{
    [Activity(Label = "ViewMap")]
    public class ViewMap : Activity, GoogleMap.IOnInfoWindowClickListener, ILocationListener, GoogleMap.IInfoWindowAdapter
    {
        private LatLng Passchendaele = new LatLng(50.897778, 3.013333);
        private LatLng VimyRidge = new LatLng(41.4034486269351, 2.17529833316803);

        private GoogleMap _map;
        private MapFragment _mapFragment;

        private Location _currentLocation;
        private LocationManager _locationManager;
        private Requests.IncidenceRequest inc;

        private long close = 0;


        private Marker myMarker;

        private Timer timer;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your fragment here
            SetContentView(Resource.Layout.MapLayout);
            this.Title = "CityCare - Mapa";
            // Create your application here
            inc = new Requests.IncidenceRequest();
            setLocationManager();
            Location loc = _locationManager.GetLastKnownLocation(LocationManager.NetworkProvider);
            OnLocationChanged(loc);
            InitMapFragment();
            loadTimer();

        }

        private void loadTimer()
        {
            timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(timerAction);
            timer.Interval = 1000000;
            timer.Enabled = true;
            timer.Start();
        }

        private void timerAction(object sender, ElapsedEventArgs e)
        {
            RunOnUiThread(() => loadMarks());
        }

        private void InitMapFragment()
        {
            _mapFragment = FragmentManager.FindFragmentByTag("map") as MapFragment;
            if (_mapFragment == null)
            {
                GoogleMapOptions mapOptions = new GoogleMapOptions()
                    .InvokeMapType(GoogleMap.MapTypeNormal)
                    .InvokeZoomControlsEnabled(false)
                    .InvokeCompassEnabled(true);

                FragmentTransaction fragTx = FragmentManager.BeginTransaction();
                _mapFragment = MapFragment.NewInstance(mapOptions);
                fragTx.Add(Resource.Id.map, _mapFragment, "map");
                fragTx.Commit();
            }
        }

        private void loadMarks()
        {
            _map.Clear();
            Toast.MakeText(this, "Actualizando marcas del mapa", ToastLength.Long).Show();
            Requests.IncidenceRequest inc = new Requests.IncidenceRequest();
            List<JSON.Incidence> inci = inc.getAllIncidencesData();
            List<LatLng> location = new List<LatLng>();
            foreach (JSON.Incidence incidence in inci)
            {
                if (incidence.status < 3 || incidence.status == 5)
                {
                    MarkerOptions marker = new MarkerOptions();
                    marker.SetPosition(new LatLng(Convert.ToDouble(incidence.lat, CultureInfo.InvariantCulture),
                        Convert.ToDouble(incidence.lng, CultureInfo.InvariantCulture)));
                    marker.SetTitle(incidence.street);
                    marker.SetSnippet(incidence.title + ": " + incidence._id);
                    _map.AddMarker(marker);
                }
            }
        }

        private void setMarkers()
        {
            if (_map == null)
            {
                _map = _mapFragment.Map;
                _map.SetOnInfoWindowClickListener(this);
                _map.SetInfoWindowAdapter(this);

                if (_map != null)
                {
                    loadMarks();
                    myMarker = _map.AddMarker(new MarkerOptions().SetPosition(new LatLng(_currentLocation.Latitude, _currentLocation.Longitude)).SetIcon(BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueBlue)));
                    // We create an instance of CameraUpdate, and move the map to it.
                    CameraUpdate cameraUpdate = CameraUpdateFactory.NewLatLngZoom(new LatLng(_currentLocation.Latitude, _currentLocation.Longitude), 15);
                    _map.MoveCamera(cameraUpdate);
                }
            }
        }

        private void setMyMarker()
        {
            myMarker.Remove();
            myMarker = _map.AddMarker(new MarkerOptions().SetPosition(new LatLng(_currentLocation.Latitude, _currentLocation.Longitude)).SetIcon(BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueBlue)));
        }



        public void OnInfoWindowClick(Marker marker)
        {
            string id = marker.Snippet.Substring(marker.Snippet.Length - 24, 24);
            Intent intent = new Intent(this, typeof(ViewIncidenceDetailed));
            intent.PutExtra("id", id);
            StartActivity(intent);
        }

        private void setLocationManager()
        {
            _locationManager = GetSystemService(Context.LocationService) as LocationManager;
            if (_locationManager.AllProviders.Contains(LocationManager.NetworkProvider)
                    && _locationManager.IsProviderEnabled(LocationManager.NetworkProvider))
            {
                _locationManager.RequestLocationUpdates(LocationManager.NetworkProvider, 1000, 1, this);
            }
            else
            {
                Toast.MakeText(this, "The Network Provider does not exist or is not enabled!", ToastLength.Long).Show();
            }
        }

        public void OnLocationChanged(Location location)
        {
            _currentLocation = location;
            if (_map != null)
            {
                if (myMarker != null)
                {
                    setMyMarker();
                }
            }
        }


        public void OnProviderDisabled(string provider) { }

        public void OnProviderEnabled(string provider) { }

        public void OnStatusChanged(string provider, Availability status, Bundle extras) { }


        public View GetInfoContents(Marker marker)
        {
            return null;
        }

        public View GetInfoWindow(Marker marker)
        {
            if (!marker.Equals(myMarker))
            {
                View myContentView = View.Inflate(this, Resource.Layout.CustomMarker, null);
                TextView mTitle = myContentView.FindViewById<TextView>(Resource.Id.title);
                TextView mSnippet = myContentView.FindViewById<TextView>(Resource.Id.snippet);
                TextView mIncidence = myContentView.FindViewById<TextView>(Resource.Id.incidenceCat);
                ImageView mImage = myContentView.FindViewById<ImageView>(Resource.Id.imageMarker);
                mTitle.Text = marker.Title;
                mSnippet.Text = marker.Snippet.Remove(marker.Snippet.Length - 26, 26);
                mIncidence.Text = Utils.IncidenceCategory.NumToString(inc.getIncidence(marker.Snippet.Substring(marker.Snippet.Length - 24, 24)).category);
                Bitmap bitmap = Bitmap.CreateScaledBitmap(Utils.BitmapUrl.GetImageBitmapFromUrl(Utils.Constants.serverAddress + "incidencias/image/" + inc.getIncidence(marker.Snippet.Substring(marker.Snippet.Length - 24, 24)).imageName), 320, 320, false);
                mImage.SetImageBitmap(bitmap);
                return myContentView;
            }
            return null;
        }

        protected override void OnResume()
        {
            base.OnResume();
            setLocationManager();
            setMarkers();
        }

        protected override void OnRestart()
        {
            base.OnRestart();
            this.Finish();
            StartActivity(typeof(ViewMap));
        }

        protected override void OnPause()
        {
            base.OnPause();
            _locationManager.RemoveUpdates(this);
        }

        public override void OnBackPressed()
        {
            if (close + 10 > SystemClock.CurrentThreadTimeMillis())
            {
                base.OnBackPressed();
            }
            else
            {
                loadMarks();
                setMyMarker();
                close = SystemClock.CurrentThreadTimeMillis();
            }
        }
    }
}