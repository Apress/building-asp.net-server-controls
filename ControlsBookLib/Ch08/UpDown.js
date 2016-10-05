function __UpDown_Check(boxid, min, max)
{
  var box = document.getElementById(boxid);

  if (isNaN(parseInt(box.value)))
    box.value = min;
  if (box.value > max)
  {
    alert('Value can not be greater than the Maximum allowed.');  
    box.value = max;
  }
  if (box.value < min)
  {
    alert('Value can not be less than than the Minimum.');  
    box.value = min;
  }
} 

function __UpDown_Up(boxid, min, max, howmuch)
{
  var box = document.getElementById(boxid);

  var newvalue = parseInt(box.value) + howmuch;
  if ((newvalue <= max) && (newvalue >= min))
    box.value = newvalue;
}
        
function __UpDown_Down(boxid, min, max, howmuch)
{
  var box = document.getElementById(boxid);

  var newvalue = parseInt(box.value) - howmuch;
  if ((newvalue <= max) && (newvalue >= min))
    box.value = newvalue;
}
