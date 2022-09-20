package md54129b58ef769f7888528ea3ea43b0489;


public class ShareActivity_State
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Xamarin.Social.ShareActivity+State, Xamarin.Social", ShareActivity_State.class, __md_methods);
	}


	public ShareActivity_State ()
	{
		super ();
		if (getClass () == ShareActivity_State.class)
			mono.android.TypeManager.Activate ("Xamarin.Social.ShareActivity+State, Xamarin.Social", "", this, new java.lang.Object[] {  });
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
