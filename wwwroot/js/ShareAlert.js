let ShareAlert = () => {
    swalWithPrimaryButton.fire({
        html: `<input type='text' disabled value='${document.URL}'class='form-control'> </input>`,
    });
}



const swalWithPrimaryButton = Swal.mixin({
    customClass: {
        confirmButton: 'btn btn-primary btn-sm btn-block'
    },
    title: "Share",
    buttonText: 'Copy URL',
    confirmButtonText: 'Copied',
    buttonsStyling: false
});