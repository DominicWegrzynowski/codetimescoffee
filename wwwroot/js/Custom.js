let index = 0;

let AddTag = () => {
    //get reference to the tag entry input
    var tagEntry = document.getElementById("TagEntry");

    //Call search function to detect duplicates or empty input
    let searchResult = Search(tagEntry.value);

    if (searchResult != null) {
        //Trigger sweetalert for whatever condition is contained in the searchResult variable
        swalWithPrimaryButton.fire({
            html: `<span class='fw-bolder'>${searchResult.toUpperCase()}</span>`
        });
    }
    else {
        //Create a new select option
        let newOption = new Option(tagEntry.value, tagEntry.value);
        document.getElementById("TagList").options[index++] = newOption;
        newOption.classList.add("tagListOptions");
    }

    //clear out tag entry textbox
    tagEntry.value = "";
    
    return true; 
};
 
let DeleteTag = () => {

    let tagCount = 1;
    let tagList = document.getElementById("TagList");

    if (!tagList) return false;
    if (tagList.selectedIndex == -1) {
        swalWithPrimaryButton.fire({
            html: "<span class='fw-bolder'>CHOOSE A TAG BEFORE DELETING</span>"
        });
        return true;
    }

    while (tagCount > 0) {

        if (tagList.selectedIndex >= 0) {
            tagList.options[tagList.selectedIndex] = null;
            --tagCount;
        }
        else {
            tagCount = 0;
        }

        index--;

    }
};

$("form").on("submit", function () {
    $("#TagList option").prop("selected", "selected");
});

let ReplaceTag = (tag, index) => {
    let newOption = new Option(tag, tag);
    document.getElementById("TagList").options[index] = newOption;
    newOption.classList.add("tagListOptions");
};

//Look for the tagValues variable to see if it has data
if (tagValues != "") {

    let tagArray = tagValues.split(",");

    for (let i = 0; i < tagArray.length; i++) {
        //Load or replace the options 
        ReplaceTag(tagArray[i], i);
        index++;
    }
}

//The search function will detect either an empty or a duplicate Tag
//and return an error string if an error is detected
let Search = (str) => {

    if (str == "") {
        return 'Please provide a valid tag for this post';
    }

    var tagsElement = document.getElementById('TagList');

    if (tagsElement) {

        let options = tagsElement.options;

        for (let i = 0; i < options.length; i++) {

            if (options[i].value == str) {
                return `${str} is already a tag for this post`;
            }

        }

    }

}



const swalWithPrimaryButton = Swal.mixin({
    customClass: {
        confirmButton: 'btn btn-primary btn-sm btn-block'
    },
    imageUrl: '/img/oops.png',
    timer: 3000,
    buttonsStyling: false
});