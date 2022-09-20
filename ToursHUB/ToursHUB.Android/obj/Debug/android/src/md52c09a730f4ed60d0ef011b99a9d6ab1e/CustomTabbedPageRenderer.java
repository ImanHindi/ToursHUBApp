package md52c09a730f4ed60d0ef011b99a9d6ab1e;


public class CustomTabbedPageRenderer
	extends md58432a647068b097f9637064b8985a5e0.TabbedPageRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_dispatchDraw:(Landroid/graphics/Canvas;)V:GetDispatchDraw_Landroid_graphics_Canvas_Handler\n" +
			"";
		mono.android.Runtime.register ("ToursHUB.Renderers.CustomTabbedPageRenderer, ToursHUB.Android", CustomTabbedPageRenderer.class, __md_methods);
	}


	public CustomTabbedPageRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == CustomTabbedPageRenderer.class)
			mono.android.TypeManager.Activate ("ToursHUB.Renderers.CustomTabbedPageRenderer, ToursHUB.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public CustomTabbedPageRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == CustomTabbedPageRenderer.class)
			mono.android.TypeManager.Activate ("ToursHUB.Renderers.CustomTabbedPageRenderer, ToursHUB.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public CustomTabbedPageRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == CustomTabbedPageRenderer.class)
			mono.android.TypeManager.Activate ("ToursHUB.Renderers.CustomTabbedPageRenderer, ToursHUB.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public void dispatchDraw (android.graphics.Canvas p0)
	{
		n_dispatchDraw (p0);
	}

	private native void n_dispatchDraw (android.graphics.Canvas p0);

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
