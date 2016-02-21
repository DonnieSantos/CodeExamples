var Compute = function()
{
	var initial = Number($(".variable.initial").val());
	var yearly = Number($(".variable.yearly").val());
	var rate = Number($(".variable.rate").val());
	var years = Number($(".variable.years").val());

	var total = initial;

	for (var i=0; i<years; i++)
	{
		var interest = total * rate;
		total += interest;
		total += yearly;
	}

	total = "$" + total.toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, '$1,');
	total = total.substring(0, total.length-3);

	$(".variable.result").val(String(total));
}

$(document).ready(function()
{
	$(".variable.initial").val(8525);
	$(".variable.yearly").val(0);
	$(".variable.rate").val(0.1);
	$(".variable.years").val(50);

	Compute();

	$(".variable.initial").change(Compute);
	$(".variable.yearly").change(Compute);
	$(".variable.rate").change(Compute);
	$(".variable.years").change(Compute);
});