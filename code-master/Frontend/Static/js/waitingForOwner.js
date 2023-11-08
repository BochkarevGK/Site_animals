"use strict"

window.addEventListener('DOMContentLoaded', (e) => {

    e.preventDefault();

//     card flip

    const cardBtns = document.querySelectorAll(".card__front__btn");
    const cards = document.querySelectorAll(".cards__card");

    cardBtns.forEach(cardBtn => {
        cardBtn.addEventListener('click', () => {
            cardBtn.parentElement.parentElement.parentElement.classList.toggle("flipCard");
            cardBtn.parentElement.parentElement.parentElement.classList.add("fliped");
        });
    });

    cards.forEach(card => {
        card.addEventListener('click', (e) => {
            if (e.target.nodeName !== "BUTTON" && card.classList.contains("fliped")) {
                card.classList.toggle("flipCard");
                card.classList.remove('fliped');
            }
        })
    })
});

$(".custom-select").each(function() {
    var classes = $(this).attr("class"),
        id      = $(this).attr("id"),
        name    = $(this).attr("name");
    var template =  '<div class="' + classes + '">';
    template += '<span class="custom-select-trigger">' + $(this).attr("placeholder") + '</span>';
    template += '<div class="custom-options">';
    $(this).find("option").each(function() {
        template += '<span class="custom-option ' + $(this).attr("class") + '" data-value="' + $(this).attr("value") + '">' + $(this).html() + '</span>';
    });
    template += '</div></div>';

    $(this).wrap('<div class="custom-select-wrapper"></div>');
    $(this).hide();
    $(this).after(template);
});
$(".custom-option:first-of-type").hover(function() {
    $(this).parents(".custom-options").addClass("option-hover");
}, function() {
    $(this).parents(".custom-options").removeClass("option-hover");
});
$(".custom-select-trigger").on("click", function() {
    $('html').one('click',function() {
        $(".custom-select").removeClass("opened");
    });
    $(this).parents(".custom-select").toggleClass("opened");
    event.stopPropagation();
});
$(".custom-option").on("click", function() {
    $(this).parents(".custom-select-wrapper").find("select").val($(this).data("value"));
    $(this).parents(".custom-options").find(".custom-option").removeClass("selection");
    $(this).addClass("selection");
    $(this).parents(".custom-select").removeClass("opened");
    $(this).parents(".custom-select").find(".custom-select-trigger").text($(this).text());
});