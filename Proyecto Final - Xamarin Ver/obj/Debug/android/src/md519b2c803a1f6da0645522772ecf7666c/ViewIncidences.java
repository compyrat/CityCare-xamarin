package md519b2c803a1f6da0645522772ecf7666c;


public class ViewIncidences
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onRestart:()V:GetOnRestartHandler\n" +
			"";
		mono.android.Runtime.register ("Proyecto_Final___Xamarin_Ver.Incidences.ViewIncidences, proyecto Final - Xamarin Ver, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ViewIncidences.class, __md_methods);
	}


	public ViewIncidences () throws java.lang.Throwable
	{
		super ();
		if (getClass () == ViewIncidences.class)
			mono.android.TypeManager.Activate ("Proyecto_Final___Xamarin_Ver.Incidences.ViewIncidences, proyecto Final - Xamarin Ver, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public void onRestart ()
	{
		n_onRestart ();
	}

	private native void n_onRestart ();

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
