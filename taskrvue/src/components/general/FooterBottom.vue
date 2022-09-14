<template>
    <div class="footer">
        <a-row class="section-footer">
            <a-col :span="3"></a-col>
            <a-col :span="3"></a-col>
            <a-col :span="12">Register today! Best task management tool ever!</a-col>
            <a-col :span="3"></a-col>
            <a-col :span="3"></a-col>
        </a-row>
        <CustomParticles class="particles"></CustomParticles>
    </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import type { MenuProps } from 'ant-design-vue';
import CustomParticles from '../../components/beautifiers/CustomParticles.vue';

interface Data {
    loading: boolean,
    isOpen: string
}

export default defineComponent({
    components:{
        CustomParticles
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

    .footer {
        max-height: 50px;
    }

    .particles {
        position: relative;
    }

    .section-footer {
        display: flex;
        justify-content: center;
        align-items: center;
        margin-top: 5px;
        width: 100%;
        height: 45px;
        z-index: 5; 
        position: absolute;
    }
</style>