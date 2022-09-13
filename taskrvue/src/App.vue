<template>
  <a-layout>
    <a-layout-header>
      <HeaderTop></HeaderTop>
    </a-layout-header>
    <a-layout-content style="min-height: 1000px">
      <img alt="Vue logo" src="./assets/logo.png">
      <HelloWorld msg="Welcome to Your Vue.js + TypeScript App"/></a-layout-content>
    <a-layout-footer>
      <FooterBottom></FooterBottom>
    </a-layout-footer>
  </a-layout>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import HelloWorld from './components/HelloWorld.vue';
import HeaderTop from './components/general/HeaderTop.vue';
import FooterBottom from './components/general/FooterBottom.vue';

export default defineComponent({
  name: 'App',
  components: {
    HelloWorld,
    HeaderTop,
    FooterBottom
}
});
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}
.ant-layout-header {
  background: rgb(139, 38, 38) !important;
  color: white !important;
  position: sticky;
  top: 0;
}
.ant-layout-content {
  
}
.ant-layout-footer {
  background: rgb(61, 61, 61) !important;
  color: white !important;
  position: sticky;
  bottom: 0;
}
</style>
