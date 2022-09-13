import { createApp } from 'vue'
import App from './App.vue'

import Antd from "ant-design-vue";
import "ant-design-vue/dist/antd.css";

import Particles from "vue3-particles"

createApp(App).use(Antd).use(Particles).mount('#app')
