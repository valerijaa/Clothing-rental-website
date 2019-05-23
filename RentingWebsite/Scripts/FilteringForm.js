$(function () {

    $.getJSON("/Filtering/FilteringForm", function (Filteringform) {
        addFilteringItemToList($('#filteringcontainer ul#color-options'), Filteringform.Colors);
        addFilteringItemToList($('#filteringcontainer ul#type-options'), Filteringform.Types);
        addFilteringItemToList($('#filteringcontainer ul#size-options'), Filteringform.Sizes);
        addFilteringItemToList($('#filteringcontainer ul#fit-options'), Filteringform.Fits);

        // when form submitted
        $("#filteringcontainer form").submit(function (event) {

            // find in every category selected option ids
            var selectedColorIds = getIdsOfSelectedCheckboxesInList($('#filteringcontainer ul#color-options'));
            var selectedTypeIds = getIdsOfSelectedCheckboxesInList($('#filteringcontainer ul#type-options'));
            var selectedSizeIds = getIdsOfSelectedCheckboxesInList($('#filteringcontainer ul#size-options'));
            var selectedFitIds = getIdsOfSelectedCheckboxesInList($('#filteringcontainer ul#fit-options'));

            // set form values as on submit, form field values will be combined as query string
            $("#filteringcontainer form #colors").val(selectedColorIds.join(','));
            $("#filteringcontainer form #sizes").val(selectedSizeIds.join(','));
            $("#filteringcontainer form #fits").val(selectedFitIds.join(','));
            $("#filteringcontainer form #types").val(selectedTypeIds.join(','));
        });
    });

    $(document).on("click", '#filteringcontainer .dropdown-menu li', function (event) {
        event.stopPropagation();
        if ($('#filteringcontainer').hasClass('vama-filtering-default')) {
            $("#filteringcontainer form").submit();
        }
    });

    function getIdsOfSelectedCheckboxesInList(listElement) {
        var selectedCheckboxValues = [];
        var selectedCheckboxes = $(listElement).find("input:checked");
        $.each(selectedCheckboxes, function () {
            selectedCheckboxValues.push($(this).val());
        });
        return selectedCheckboxValues;
    }

    function addFilteringItemToList(listElement, arrayOfFilteringItem) {
        var i;
        for (i = 0; i < arrayOfFilteringItem.length; i++) {
            listElement.append(
                '<li><label><input type="checkbox" value="' + arrayOfFilteringItem[i].Id + '"/>' + arrayOfFilteringItem[i].Name + '</label></li>'
            );
        }
    }

});

