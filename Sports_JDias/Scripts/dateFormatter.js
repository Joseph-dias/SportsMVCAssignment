var items = document.getElementsByClassName("datepicker");

for (var x = 0; x < items.length; x++) {
    items[x].addEventListener('keyup', function (e) {
        if ((e.keyCode >= 48 && e.keyCode <= 57) || (e.keyCode >= 96 && e.keyCode <= 105)) {
            var num = e.target.value.length;
            if (num === 2 || num === 5) {
                var val = e.target.value;
                val += '/';
                e.target.value = val;
            } else if (num > 10) {
                var txtVal = e.target.value; //Subtract the last char
                var theNewVal = txtVal.substr(0, txtVal.length - 1);
                e.target.value = theNewVal;
            }
        } else if ((e.keyCode >= 65 && e.keyCode <= 90) || (e.keyCode >= 186 && e.keyCode === 222) || e.keyCode === 32) {
            var theVal = e.target.value; //Subtract the last char
            var newVal = theVal.substr(0, theVal.length - 1);
            e.target.value = newVal;
        }
    });
}