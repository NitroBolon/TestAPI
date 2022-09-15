<template>
  <a-steps :current="activeKey">
    <a-step>
      <!-- <span slot="title">Finished</span> -->
      <template #title>Accept regulations</template>
      <template #description>
        <span>Some necessary stuff.</span>
      </template>
    </a-step>
    <a-step title="Register" description="Create your account." />
    <a-step title="Configure dashboard" description="Personalization." />
  </a-steps>
  <a-tabs v-model:activeKey="activeTab">
    <a-tab-pane key="1">
      <RegulationsForm @regulations-change="regulationsChange"></RegulationsForm>
    </a-tab-pane>
    <a-tab-pane key="2" force-render>
      <UserForm @userform-change="userformChange"></UserForm>
    </a-tab-pane>
    <a-tab-pane key="3">
      <BoardForm></BoardForm>
    </a-tab-pane>
  </a-tabs>
  <a-divider />
  <a-row>
    <a-col :span="3"></a-col>
    <a-col :span="3">
      <a-button type="primary" shape="circle" @click="prevPage" :size="size" :disabled="!activePrev">
        <template #icon>
          <LeftOutlined />
        </template>
      </a-button>
    </a-col>
    <a-col :span="12"></a-col>
    <a-col :span="3">
      <a-button type="primary" shape="circle" @click="nextPage" :size="size" :disabled="!activeNext" v-if="!last">
        <template #icon>
          <RightOutlined />
        </template>
      </a-button>
      <a-button type="primary" shape="circle" @click="sendForm" :size="size" v-else-if="last">
        <template #icon>
          <CheckOutlined />
        </template>
      </a-button>
    </a-col>
    <a-col :span="3"></a-col>
  </a-row>
</template>

<script lang="ts">
import { defineComponent, ref } from 'vue';
import UserForm from './parts/UserForm.vue';
import BoardForm from './parts/BoardForm.vue';
import { LeftOutlined, RightOutlined, CheckOutlined } from '@ant-design/icons-vue';
import type { SizeType } from 'ant-design-vue/es/config-provider';
import RegulationsForm from './parts/RegulationsForm.vue';

export default defineComponent({
  components: {
    UserForm,
    BoardForm,
    LeftOutlined,
    RightOutlined,
    RegulationsForm,
    CheckOutlined
},
  setup() {
    const activeKey = ref(0);
    const activeTab = ref('1');
    const activePrev = ref(false);
    const last = ref(false);
    const activeNext = ref(false);
    const size = ref<SizeType>('large');

    const nextPage = () => {
      if (activeKey.value < 2) {
        activePrev.value = true;
        activeKey.value = activeKey.value + 1;
      }

      if (activeKey.value == 2) {
        activeNext.value = false;
        activeTab.value = '3';
        last.value = true;
      }
      else if (activeKey.value == 0) {
        activeTab.value = '1';
        last.value = false;
      }
      else {
        activeTab.value = '2';
        last.value = false;
        activeNext.value = false;
      }
    }
    const prevPage = () => {
      if (activeKey.value > 0) {
        activeNext.value = true;
        activeKey.value = activeKey.value - 1;
      }
      
      if (activeKey.value == 0) {
        activePrev.value = false;
        activeTab.value = '1';
        last.value = false;
      }
      else if (activeKey.value == 1) {
        activeTab.value = '2';
        last.value = false;
      }
      else {
        activeTab.value = '3';
        last.value = true;
      }
    }

    const sendForm = () => {
      
    }

    const regulationsChange = (val: boolean) => {
      activeNext.value = val;
    }

    const userformChange = (val: boolean) => {
      activeNext.value = val;
    }

    return {
      activeKey,
      size,
      nextPage,
      prevPage,
      activePrev,
      activeNext,
      sendForm,
      activeTab,
      regulationsChange,
      userformChange,
      last
    };
  },
});
</script>

<style>

</style>