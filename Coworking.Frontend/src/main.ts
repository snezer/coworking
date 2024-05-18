import { createApp } from 'vue'
//import './style.css'
import './assets/style/base.css'
import './assets/style/fonts.css'
import App from './App.vue'
import primevue from "./config/primevue.ts";
import router from "./router.ts";
import maps from "./config/maps.ts";

import { createPinia } from 'pinia'

createApp(App).use(createPinia()).use(primevue).use(maps).use(router).mount('#app')
