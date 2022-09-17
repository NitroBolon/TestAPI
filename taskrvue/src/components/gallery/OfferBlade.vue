<template>
    <a-card :bordered="selected">
        <p>name</p>
    </a-card>
</template>

<script lang="ts">
import { defineComponent } from 'vue';

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
    data(): Data {
        return {
            
        };
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