package md54129b58ef769f7888528ea3ea43b0489;


public class ShareActivity_AttachmentView
	extends android.widget.TableLayout
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Xamarin.Social.ShareActivity+AttachmentView, Xamarin.Social", ShareActivity_AttachmentView.class, __md_methods);
	}


	public ShareActivity_AttachmentView (android.content.Context p0)
	{
		super (p0);
		if (getClass () == ShareActivity_AttachmentView.class)
			mono.android.TypeManager.Activate ("Xamarin.Social.ShareActivity+AttachmentView, Xamarin.Social", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public ShareActivity_AttachmentView (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == ShareActivity_AttachmentView.class)
			mono.android.TypeManager.Activate ("Xamarin.Social.ShareActivity+AttachmentView, Xamarin.Social", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}

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
