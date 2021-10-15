let ValidateComment = () => {
    let button = document.getElementById("btnAddComment");
    

    document.getElementById("commentInput")
        .addEventListener("input", (event) => {
            if (document.getElementById("commentInput").value != "" || document.getElementById("commentInput").value != null) {
                if (button.hasAttribute("disabled")) {
                    button.removeAttribute("disabled");
                }
            }
            if (document.getElementById("commentInput").value == "" || document.getElementById("commentInput").value == null) {
                if (button.hasAttribute("disabled")) {
                    button.removeAttribute("disabled");
                }
                button.setAttribute("disabled", "");
            }
        }
    );
};