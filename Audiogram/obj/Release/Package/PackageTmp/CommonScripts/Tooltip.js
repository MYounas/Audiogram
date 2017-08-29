$(document).ready(function () {

    /**
     * store the value of and then remove the title attributes from the
     * abbreviations (thus removing the default tooltip functionality of
         * the abbreviations)
     */
    $('abbr').each(function () {

        $(this).data('title', $(this).attr('title'));
        $(this).removeAttr('title');

    });

    /**
 * when abbreviations are mouseover-ed show a tooltip with the data from the title attribute
 */


    $('abbr').mouseover(function () {

        var position = $(this).attr("data-position");
        console.log('the Position :' + position);

        // first remove all existing abbreviation tooltips
        $('abbr').next('.customtooltip').remove();

        // create the tooltip
        $(this).after('<span class="customtooltip tooltip">' + $(this).data('title') + '</span>');

        $(this).next().animate({ opacity: 0.9 }, {
            duration: 100, complete: function () {
                $(this).fadeOut(50000);
            }
        });
        // position the tooltip 4 pixels above and 4 pixels to the left of the abbreviation
        //var left = $(this).position().left + $(this).width() + 4;

        if (position == "right")
            var left = $(this).position().left - $(this).width() - 290;
        else if (position == "left")
            var left = $(this).position().left - $(this).width() + 50;
        var top = $(this).position().top - 4;
        $(this).next().css('left', left);
        $(this).next().css('top', top);

    });

    /**
     * when abbreviations are clicked trigger their mouseover event then fade the tooltip
     * (this is friendly to touch interfaces)
     */
    $('abbr').click(function () {

        $(this).mouseover();

        // after a slight 2 second fade, fade out the tooltip for 1 second
        $(this).next().animate({ opacity: 0.9 }, {
            duration: 100, complete: function () {
                $(this).fadeOut(50000);
            }
        });

    });

    /**
     * Remove the tooltip on abbreviation mouseout
     */
    $('abbr').mouseout(function () {

        $(this).next('.customtooltip').remove();

    });

});