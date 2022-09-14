<template>
    <a-row>
        <a-col :span="3"></a-col>
        <a-col :span="3"><img class="logo" src="@/assets/logo/logo-black-75-75.png" /></a-col>
        <a-col :span="12">Register today! Best task management tool ever!</a-col>
        <a-col :span="3">
            <a-dropdown>
                <template #overlay>
                    <a-menu @mouseover="handleMenuOver" @mouseleave="handleMenuLeave"  @click="handleMenuClick">
                        <a-menu-item key="1" @click="showModal1">Log in</a-menu-item>
                        <a-menu-item key="2" @click="showModal2">Sign up</a-menu-item>
                    </a-menu>
                </template>
                <a-button type="text">
                    Your dashboard
                    <DownOutlined />
                </a-button>
            </a-dropdown>
        </a-col>
        <a-col :span="3"></a-col>
    </a-row>
    <a-modal v-model:visible="visible" title="Sign in or register new dashboard" footer="Remember to keep your credentials safe!" width="50%">
        <a-tabs v-model:activeKey="activeKey">
            <a-tab-pane key="1" tab="Log in">
                <LoginInput></LoginInput>
            </a-tab-pane>
            <a-tab-pane key="2" tab="Register" force-render>
                <RegisterInput></RegisterInput>
            </a-tab-pane>
        </a-tabs>
    </a-modal>
</template>

<script lang="ts">
import { defineComponent, ref } from "vue";
import type { MenuProps } from 'ant-design-vue';
import LoginInput from '../../components/auth/LoginInput.vue';
import RegisterInput from '../../components/auth/RegisterInput.vue';

interface Data {
    loading: boolean,
    isOpen: string
}

export default defineComponent({
    components: {
        LoginInput,
        RegisterInput
    },
    data(): Data {
        return {
            loading: false,
            isOpen: 'false'
        };
    },
    created() {
        
    },
    watch: {

    },
    methods: {
    },
    setup() {
        const visible = ref<boolean>(false);
        const activeKey = ref('2');
        const handleMenuClick: MenuProps['onClick'] = e => {
            console.log('click', e);
        };
        const handleMenuLeave: MenuProps['onClick'] = e => {
            console.log('click', e);
        };
        const handleMenuOver: MenuProps['onClick'] = e => {
            console.log('click', e);
        };
        const showModal1 = () => {
            activeKey.value = '1';
            visible.value = true;
        };
        const showModal2 = () => {
            activeKey.value = '2';
            visible.value = true;
        };
        return {
            handleMenuLeave,
            handleMenuClick,
            handleMenuOver,
            visible,
            activeKey,
            showModal1,
            showModal2
        };
    },
});
</script>

<style>
    .logo {
        max-width: 75%;
        max-height: 75%;
    }
</style>