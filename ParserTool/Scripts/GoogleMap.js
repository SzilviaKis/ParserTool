$.getScript('https://maps.googleapis.com/maps/api/js').done(handleMapsAPILoaded);

function handleMapsAPILoaded() {
    var isDraggable = !('ontouchstart' in document.documentElement);
    var maps = [];
    var latlngs = [];

    $('.contact-map').each(function () {
        var $this = $(this);
        var latlng = new google.maps.LatLng($this.data('map-lat'), $this.data('map-lng'));

        var map = new google.maps.Map($this[0], {
            zoom: 15,
            center: latlng,
            disableDefaultUI: false,
            scrollwheel: false,
            draggable: isDraggable
        });

        maps.push(map);
        latlngs.push(latlng);
    });

    $(window).on('resize', function () {
        $.each(maps, function (mapIndex, mapItem) {
            google.maps.event.trigger(mapItem, 'resize');
            mapItem.setCenter(latlngs[mapIndex]);
        })
    });
}
