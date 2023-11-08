"use strict"

window.addEventListener('DOMContentLoaded', (e) => {

    e.preventDefault();

    // Checkbox

    const inputCheckbox = document.querySelector('input[type = "checkbox"]');

    inputCheckbox.addEventListener("click", () => {
        inputCheckbox.toggleAttribute("checked");
    })

    // Animation for inputs

    const textInputs = document.querySelectorAll('input[type = "text"]');
    const numberInputs = document.querySelectorAll('input[type = "number"]');

    function transformLabels(inputs) {
        inputs.forEach( input => {
            input.addEventListener('focus', () => {
                input.previousElementSibling.classList.add("label-focus");
                input.parentElement.classList.add("pay-form__requisites__form__item--focus");
            });
            input.addEventListener('blur', () => {
                if (input.value == "") {
                    input.previousElementSibling.classList.remove("label-focus");
                    input.parentElement.classList.remove("pay-form__requisites__form__item--focus");
                }
            })
        })
    };

    transformLabels(textInputs);
    transformLabels(numberInputs);

    // Chart

    const allDonatedMoney = "45000";
    const maxMoney = "100000";
    const chartDonated = document.querySelector('.chart-donated');
    const allDonatedMoneyElement = document.querySelector('.pay-form__statistics--sum');

    const percent = +allDonatedMoney / +maxMoney;

    chartDonated.style.width = (300 * percent) + "px";
    allDonatedMoneyElement.textContent = numberWithSpaces(+allDonatedMoney);

    function numberWithSpaces(x) {
        return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, " ");
    }
});