package md5dba3639a64ff586d3def216c245003c8;


public class CircleEffect_CircleOutlineProvider
	extends android.view.ViewOutlineProvider
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getOutline:(Landroid/view/View;Landroid/graphics/Outline;)V:GetGetOutline_Landroid_view_View_Landroid_graphics_Outline_Handler\n" +
			"";
		mono.android.Runtime.register ("ToursHUB.Droid.Effects.CircleEffect+CircleOutlineProvider, ToursHUB.Android", CircleEffect_CircleOutlineProvider.class, __md_methods);
	}


	public CircleEffect_CircleOutlineProvider ()
	{
		super ();
		if (getClass () == CircleEffect_CircleOutlineProvider.class)
			mono.android.TypeManager.Activate ("ToursHUB.Droid.Effects.CircleEffect+CircleOutlineProvider, ToursHUB.Android", "", this, new java.lang.Object[] {  });
	}


	public void getOutline (android.view.View p0, android.graphics.Outline p1)
	{
		n_getOutline (p0, p1);
	}

	private native void n_getOutline (android.view.View p0, android.graphics.Outline p1);

	private java.util.ArrayList refList;
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
