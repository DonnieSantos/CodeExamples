package
{
	import flash.utils.ByteArray;
	import flash.display.*;

	public class Image
	{
		[Embed(source='/../images/Lady.png')]
		private static var ImageClass_Lady:Class;
		public static var Lady:Bitmap = new ImageClass_Lady();
	}
}