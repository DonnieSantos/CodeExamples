package
{
	import fl.transitions.Tween;
	import fl.transitions.easing.None;
	
	import flash.display.*;

	public class TransformMovieClip
	{
		public static function TranslateX(movieClip:MovieClip, xBegin:int, xEnd:int, frames:int):void
		{
			new Tween(movieClip, "x", None.easeOut, xBegin, xEnd, frames, false);
		}
	}
}