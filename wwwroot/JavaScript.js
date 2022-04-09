class GoogleMap {
    constructor() {
        google.maps.visualRefresh = true;
        this.init();
    }
    init = () => {
        google.maps.visualRefresh = true;
        // установка основных координат
        var Moscow = new google.maps.LatLng(55.752622, 37.617567);

        // Установка общих параметров отображения карты, как масштаб, центральная точка и тип карты
        var mapOptions = {
            zoom: 15,
            center: Moscow,
            mapTypeId: google.maps.MapTypeId.G_NORMAL_MAP
        };

        // Встраиваем гугл-карты в элемент на странице и получаем объект карты
        var map = new google.maps.Map(document.getElementById("canvas"), mapOptions);

        // Настраиваем красный маркер, который будет использоваться для центральной точки
        var myLatlng = new google.maps.LatLng(55.752622, 37.617567);

        var marker = new google.maps.Marker({
            position: myLatlng,
            map: map,
            title: 'Станции метро'
        });

        // Берем для маркера иконку с сайта google
        marker.setIcon('http://maps.google.com/mapfiles/ms/icons/red-dot.png')
    }
}
new GoogleMap();