const checkboxes = [
    document.getElementById("btncheck1"),
    document.getElementById("btncheck4"),
    document.getElementById("btncheck6"),
    document.getElementById("btncheck7"),
    document.getElementById("btncheck8"),
    document.getElementById("btncheck9"),
    document.getElementById("btncheck12")
];

const uncheckedboxes = [
    document.getElementById("btncheck2"),
    document.getElementById("btncheck3"),
    document.getElementById("btncheck5"),
    document.getElementById("btncheck10"),
    document.getElementById("btncheck11")
]

const buttonButtonEx16 = document.getElementById("buttonButtonEx16");

checkboxes.forEach(checkbox => {
    checkbox.addEventListener("change", updateButton);
});

uncheckedboxes.forEach(uncheckbox => {
    uncheckbox.addEventListener("change", updateButton);
})

function updateButton() {
    const allChecked = checkboxes.every(checkbox => checkbox.checked);
    const allUnchecked = uncheckedboxes.some(uncheckbox => uncheckbox.checked);
    if (allChecked && !allUnchecked) {
        buttonButtonEx16.classList.remove("d-none");
    } else {
        buttonButtonEx16.classList.add("d-none");
    }
}