package
{
	import flash.display.MovieClip;

	[SWF(width=640,height=480,backgroundColor=0xFFFFFF)]
	public class Test extends MovieClip
	{
		public function Test()
		{
			Draw.Line(this, 0, 0, 300, 300, 0xff0000, 10, 1.0);
			Draw.Line(this, 300, 0, 0, 300, 0x0000ff, 10, 0.2);
			Draw.Rectangle(this, 300, 300, 400, 400, 0x00ff00, 2, 1.0, 0xff00ff, -1, 10, 10, 10, 10);			
			Draw.Text(this, Fonts.BlackFont, "Hello World", false, false, 450, 450);

			var firstChild:MovieClip = new MovieClip();
			firstChild.addChild(Image.Lady);
			this.addChild(firstChild);

			TransformMovieClip.TranslateX(firstChild, 0, 150, 50);
		}
	}
}