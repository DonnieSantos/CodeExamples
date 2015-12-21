package
{
	import flash.display.*;
	import flash.geom.*;
	import flash.text.*;
	
	public class Draw
	{
		public static function Line(movieClip:MovieClip, x1:int, y1:int, x2:int, y2:int, color:Number, thickness:int=1, alpha:Number=1.0):void
		{
			movieClip.graphics.lineStyle(thickness, color, alpha);
			movieClip.graphics.moveTo(x1, y1);
			movieClip.graphics.lineTo(x2, y2);
		}

		public static function Rectangle(movieClip:MovieClip, x1:int, y1:int, x2:int, y2:int, borderColor:Number, thickness:int, alpha:Number, fillColorBegin:Number=-1, fillColorEnd:Number=-1, upperLeftRadius:int=0, lowerLeftRadius:int=0, lowerRightRadius:int=0, upperRightRadius:int=0, ty:int=0):void
		{
			beginGradientFill(movieClip.graphics, fillColorBegin, fillColorEnd, alpha, x2-x1, y2-y1, ty);
			movieClip.graphics.lineStyle(thickness, borderColor, alpha, true);
			movieClip.graphics.drawRoundRectComplex(x1, y1, x2-x1, y2-y1, upperLeftRadius, upperRightRadius, lowerLeftRadius, lowerRightRadius);
			endGradientFill(movieClip.graphics, fillColorBegin, fillColorEnd);
		}
		
		private static function beginGradientFill(g:Graphics, colorBegin:Number, colorEnd:Number, alpha:Number, width:int, height:int, ty:int=0):void
		{
			if (colorBegin == -1) return;

			if (colorEnd == -1)
			{
				g.beginFill(colorBegin, alpha);
			}
			else
			{
				var colors:Array = [colorBegin, colorEnd];
				var alphas:Array = [alpha, alpha];
				var ratios:Array = [90, 255];
				var matrix:Matrix = new Matrix();
				matrix.createGradientBox(width, height, toRadians(90), 0, 0);
				g.beginGradientFill(GradientType.LINEAR, colors, alphas, ratios, matrix, SpreadMethod.PAD);
			}
		}
		
		private static function toRadians(degrees:Number):Number
		{
			return degrees * Math.PI/180;
		}
		
		private static function endGradientFill(g:Graphics, colorBegin:Number, colorEnd:Number):void
		{
			if (colorBegin == -1) return;
			g.endFill();
		}
		
		public static function Text(movieClip:MovieClip, textFormat:TextFormat, text:String, embedFonts:Boolean=false, wordWrap:Boolean=false, x:int=0, y:int=0, width:int=0, height:int=0, autoSize:String=TextFieldAutoSize.LEFT):TextField
		{
			var txt:TextField = new TextField();
			txt.x = x;
			txt.y = y;
			txt.antiAliasType = AntiAliasType.NORMAL;
			txt.sharpness = 400;
			txt.width = width;
			txt.height = height;
			txt.autoSize = autoSize;
			txt.selectable = false;
			txt.mouseEnabled = false;
			txt.embedFonts = embedFonts;
			txt.wordWrap = wordWrap;
			if (text != null) {	txt.text = text; }
			txt.setTextFormat(textFormat);
			movieClip.addChild(txt);
			return txt;
		}
	}
}