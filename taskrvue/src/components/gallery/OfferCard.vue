<template>
    <a-card title="title" :bordered="selected">
        <a-space>
            <star-filled></star-filled>
            <star-filled></star-filled>
            <star-outlined></star-outlined>
        </a-space>
        <p>name</p>
    </a-card>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import { StarOutlined, StarFilled} from '@ant-design/icons-vue';

interface Data {
    
}

export default defineComponent({
    props: {
        subscriptions: Number,
        name: String, 
        validMonths: Number,
        priceMonth: Number,
        selected: Boolean
    },
    components: {
        StarOutlined,
        StarFilled
    },
    data(): Data {
        return {
            
        };
    },
    setup() {
        
    },
    created() {
        
    },
    watch: {
        
    },
    methods: {

    }
});
</script>

<style>

</style>