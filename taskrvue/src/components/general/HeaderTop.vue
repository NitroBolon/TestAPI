<template>
    <a-row>
        <a-col :span="3"></a-col>
        <a-col :span="3"><img class="logo" src="@/assets/logo/logo-black-75-75.png" /></a-col>
        <a-col :span="12">Register today! Best task management tool ever!</a-col>
        <a-col :span="3">
            <a-dropdown>
                <template #overlay>
                    <a-menu @mouseover="handleMenuOver" @mouseleave="handleMenuLeave"  @click="handleMenuClick">
                        <a-menu-item key="1">Log in</a-menu-item>
                        <a-menu-item key="2">Sign in</a-menu-item>
                    </a-menu>
                </template>
                <a-button type="text">
                    Log in
                    <DownOutlined />
                </a-button>
            </a-dropdown>
        </a-col>
        <a-col :span="3"></a-col>
    </a-row>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import type { MenuProps } from 'ant-design-vue';

interface Data {
    loading: boolean,
    isOpen: string
}

export default defineComponent({
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
        const handleMenuClick: MenuProps['onClick'] = e => {
            console.log('click', e);
        };
        const handleMenuLeave: MenuProps['onClick'] = e => {
            console.log('click', e);
        };
        const handleMenuOver: MenuProps['onClick'] = e => {
            console.log('click', e);
        };
        return {
            handleMenuLeave,
            handleMenuClick,
            handleMenuOver,
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