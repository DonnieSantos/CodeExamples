package
{
	import flash.text.*;

	public class Fonts
	{
		public static var RedFont:TextFormat = CreateTextFormat("Verdana", 15, 0xff0000, true, false, "left");
		public static var BlackFont:TextFormat = CreateTextFormat("Verdana", 15, 0x000000, true, false, "left");
		
		public static function CreateTextFormat(fontName:String, size:int, color:Number, bold:Boolean, underline:Boolean, align:String, italic:Boolean=false):TextFormat
		{
			var textFormat:TextFormat = new TextFormat();
			textFormat.italic = italic;
			textFormat.font = fontName;
			textFormat.color = color;
			textFormat.bold = bold;
			textFormat.underline = underline;
			textFormat.size = size;
			textFormat.align = align;
			return textFormat;
		}
	}
}