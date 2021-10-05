let index = 0;

let AddTag = () => {
    //get reference to the tag entry input
    var tagEntry = document.getElementById("TagEntry");

    if (tagEntry.value === "") {
        alert("Tag entry must contain a value!");
    }
    else {
        //Create a new select option
        let newOption = new Option(tagEntry.value, tagEntry.value);
        document.getElementById("TagList").options[index++] = newOption;
        newOption.classList.add("tagListOptions");
        //clear out tag entry textbox
        tagEntry.value = "";
    }
    return true; 
};
 
let DeleteTag = () => {
    let tagCount = 1;
    while (tagCount > 0) {
        let tagList = document.getElementById("TagList");
        let selectedIndex = tagList.selectedIndex;
        if (selectedIndex >= 0) {
            tagList.options[selectedIndex] = null;
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

