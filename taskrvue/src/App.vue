<template>
  <a-layout>
    <a-layout-header>
      <HeaderTop></HeaderTop>
    </a-layout-header>
    <a-layout-content style="min-height: 1000px">
      <img alt="Vue logo" src="./assets/logo.png">
      <HomePage></HomePage>
    </a-layout-content>
    <a-layout-footer>
      <FooterBottom></FooterBottom>
    </a-layout-footer>
  </a-layout>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import HeaderTop from './components/general/HeaderTop.vue';
import FooterBottom from './components/general/FooterBottom.vue';
import HomePage from './components/general/HomePage.vue';

export default defineComponent({
  name: 'App',
  components: {
    HeaderTop,
    FooterBottom,
    HomePage
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
  z-index: 5;
  top: 0;
}
.ant-layout-content {
  width: 75%;
  display: block !important;
  margin-left: auto !important;
  margin-right: auto !important;
}
.ant-layout-footer {
  background: rgb(61, 61, 61) !important;
  color: white !important;
  padding: 0 !important;
  height: 60px;
  position: sticky;
  bottom: 0;
}
</style>
