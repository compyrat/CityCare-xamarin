package md519b2c803a1f6da0645522772ecf7666c;


public class ViewIncidenceDetailed
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Proyecto_Final___Xamarin_Ver.Incidences.ViewIncidenceDetailed, proyecto Final - Xamarin Ver, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ViewIncidenceDetailed.class, __md_methods);
	}


	public ViewIncidenceDetailed () throws java.lang.Throwable
	{
		super ();
		if (getClass () == ViewIncidenceDetailed.class)
			mono.android.TypeManager.Activate ("Proyecto_Final___Xamarin_Ver.Incidences.ViewIncidenceDetailed, proyecto Final - Xamarin Ver, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
