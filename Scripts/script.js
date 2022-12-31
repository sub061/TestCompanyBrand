// Jquery Dependency

// disable required 
$(document).ready(() => {
    $('input:checkbox').change(() => {
        let id = removePrefix(event.target.id);
        // Disabling Inputs
        (event.target.checked) ? 
            document.getElementById(id).disabled = true
            : document.getElementById(id).disabled = false;
        
        // Disabling Date Picker
        if(document.getElementById(id+'Date')){
            (event.target.checked) ? 
                document.getElementById(id+'Date').disabled = true
                : document.getElementById(id+'Date').disabled = false;
        }
        

        // Disabling File Upload

    })
});

const removePrefix = (str) => {
    const [prefix, ...rest] = str.split('_');
    return rest.join();
}

$('#btnSubmit').on('click', function () {
    
});


function formatCurrency(input, blur) {
    // appends $ to value, validates decimal side
    // and puts cursor back in right position.

    // get input value
    var input_val = input.val();

    // don't validate empty input
    if (input_val === "") { return; }

    // original length
    var original_len = input_val.length;

    // initial caret position 
    var caret_pos = input.prop("selectionStart");

    // check for decimal
    if (input_val.indexOf(".") >= 0) {

        // get position of first decimal
        // this prevents multiple decimals from
        // being entered
        var decimal_pos = input_val.indexOf(".");

        // split number by decimal point
        var left_side = input_val.substring(0, decimal_pos);
        var right_side = input_val.substring(decimal_pos);

        // add commas to left side of number
        left_side = formatNumber(left_side);

        // validate right side
        right_side = formatNumber(right_side);

        // On blur make sure 2 numbers after decimal
        if (blur === "blur") {
            right_side += "00";
        }

        // Limit decimal to only 2 digits
        right_side = right_side.substring(0, 2);

        // join number by .
        input_val = "$" + left_side + "." + right_side;

    } else {
        // no decimal entered
        // add commas to number
        // remove all non-digits
        input_val = formatNumber(input_val);
        input_val = "$" + input_val;

        // final formatting
        if (blur === "blur") {
            input_val += ".00";
        }
    }

    // send updated string to input
    input.val(input_val);

    // put caret back in the right position
    var updated_len = input_val.length;
    caret_pos = updated_len - original_len + caret_pos;
    input[0].setSelectionRange(caret_pos, caret_pos);
}

const fakeProgress = (progressId, successId) => {
    let progress = document.getElementById(progressId);
    let success = document.getElementById(successId);
    console.log(progress.value);
    if (progress.value >= 100) {
        //clearInterval(fakeProgress);
        progress.style.display = "none";
        success.style.display = "block";
        return;
    }
    console.log('PROgressing.....')
    progress.value += 10;
};

function fileUpload1(event, progressid, successid) { }

const isPDF = (file) => {
    return ['pdf', 'PDF'].includes(file.name.split('.')[1]);
}

const isLessThan10MB = (file) => {
    return file.size < 10000000;
}
debugger
const fileUpload = (event, progressId, successId) => {
    const file = document.getElementById(event.target.id).files[0];
    if(isPDF(file) && isLessThan10MB(file)) {
        event.target.style.opacity = 0.5;
        event.target.disabled = false;
        document.getElementById(progressId).style.display = 'block';
        setInterval(fakeProgress, 500, progressId, successId);
    } else{
        alert('Only PDF files are allowed and it should be less than 10MB in size');
    }
}

// function fileUpload(event, progressid, successid) {
//     progress = document.getElementById(progressid);
//     success = document.getElementById(successid);
//     myFile = document.getElementById(event.target.id)
//     if (
//         myFile.files[0].name.split(".")[1] === "pdf" ||
//         myFile.files[0].name.split(".")[1] === "PDF"
//     ) {
//         if (myFile.files[0].size < 10000000) {
//             console.log(progress);
//             const i = event.target;
//             i.style.opacity = 0.5;
//             i.disabled = false;
//             progress.style.display = "block";
//             setInterval(fakeProgress, 500);
//         } else {
//             alert("file size should be less than 10 mb")
//         }
//     } else {
//         alert("use pdf file only");
//         return;
//     }
// }