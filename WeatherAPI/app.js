var search = document.querySelector('.search')
async function changeWeatherUI(weather) {
    var city = document.querySelector('.city')
    var country = document.querySelector('.country')
    var value = document.querySelector('.value')
    var ShortDesc = document.querySelector('.short-desc')
    var visibility = document.querySelector('.visibility span')
    var wind = document.querySelector('.wind span')
    var sun = document.querySelector('.sun span')
    var time = document.querySelector('.time')

    city.innerText = weather.name
    country.innerText = weather.sys.country
    visibility.innerText = weather.visibility + 'm'
    wind.innerText = weather.wind.speed + 'm/s'
    sun.innerText = weather.main.humidity + '%'

    const temp = Math.round(weather.main.temp)
    value.innerHTML = temp

    temp >= 21 ?
        (document.body.className = 'hot') :
        (document.body.className = 'cold')

    ShortDesc.innerHTML = weather.weather[0].main
    time.innerText = new Date().toLocaleDateString('vi')


}
search.addEventListener('keypress', (e) => {
    if (e.keyCode === 13) {
        getWeatherUI(e.target.value)
    }
})
async function getWeatherUI(search) {
    let apiUrl = `https://api.openweathermap.org/data/2.5/weather?q=${search}&units=metric&appid=d78fd1588e1b7c0c2813576ba183a667`
    const data = await fetch(apiUrl)
    const weather = await data.json()
    changeWeatherUI(weather)
}
getWeatherUI('ha noi')