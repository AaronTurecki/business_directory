var map;
function setMap(long, lat) {
    var mapProp = {
        center: new google.maps.LatLng(long, lat),
        zoom: 12,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    map = new google.maps.Map(document.getElementById("googleMap"), mapProp);
}

function initialize() {
    
    var latitude = document.getElementById("latitude").textContent;
    var longitude = document.getElementById("longitude").textContent;

    var myCenter = new google.maps.LatLng(latitude, longitude);
    var mapProp = {
        center: myCenter,
        zoom: 5,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    var map = new google.maps.Map(document.getElementById("googleMap")
        , mapProp);
    var marker = new google.maps.Marker({
        map: map,
        position: myCenter
    });
    marker.setMap(map);
}

function initializeMap() {
    codeAddress();
    $('#verify').show();
    $('#checkbox').show();
}

function initializeSubmit() {
    $('#submit').show();
}

function clearChildren(htmlNode) {
    while (htmlNode.firstChild) {
        htmlNode.removeChild(htmlNode.firstChild);
    }
}
function codeAddress() {
    var geocoder = new google.maps.Geocoder();
    var street = document.getElementById('address').value;
    var city = document.getElementById('city').value;
    var province = document.getElementById('province').value;
    var postalCode = document.getElementById('postalCode').value;
    var Country = document.getElementById('country').value;

    var address = street + " " + city + " " + province + " " + postalCode + " " + country;

    geocoder.geocode({ 'address': address }, function (results, status) {

        if (status == google.maps.GeocoderStatus.OK) {
            var strLat = results[0].geometry.location.lat();
            var strLng = results[0].geometry.location.lng();

            $('#latitude').val(strLat);
            $('#longitude').val(strLng);

            setMap(strLng, strLat);
            map.setCenter(results[0].geometry.location);
            var marker = new google.maps.Marker({
                map: map,
                position: results[0].geometry.location
            });

        } else {
            alert('Geocode was not successful for the following reason: ' + status);
        }
    });
}


