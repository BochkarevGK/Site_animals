"use strict"

window.addEventListener('DOMContentLoaded', (e) => {

    e.preventDefault();

    const btn = document.querySelector("[data-modal]"),
          modal = document.querySelector(".modal"),
          closeModal = modal.querySelector(".adding-entry__cross");

    btn.addEventListener("click", () => {
        modal.classList.toggle("none");
    });

    closeModal.addEventListener("click", () => {
        modal.classList.toggle("none");
    });

});
