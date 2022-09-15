<template>
    <div>
        <a-checkbox v-model:checked="checkedList[0]">
            Confirm knowledge of our <a href="https://google.com/" target="_blank">regulations</a> and accept <a href="https://google.com/" target="_blank">agreements</a>.
        </a-checkbox>
    </div>
    <div>
        <a-checkbox v-model:checked="checkedList[1]">
            Accept our <a href="https://google.com/" target="_blank">privacy policy</a>.
        </a-checkbox>
    </div>
    <div>
        <a-checkbox v-model:checked="checkedList[2]">Allow us to send some news and exclusive offers.</a-checkbox>
    </div>
    <div>
        <a-checkbox v-model:checked="checkAll" :indeterminate="indeterminate" @change="onCheckAllChange">
            Check all
        </a-checkbox>
        <a-button type="text" @click="onCheckNecessaryChange">
            Check necessary
        </a-button>
    </div>
</template>

<script lang="ts">
import { defineComponent, reactive, toRefs, watch } from 'vue';

export default defineComponent({
    setup(props, { emit }) {
        const state = reactive({
            indeterminate: true,
            checkAll: false,
            checkedList: [false, false, true]
        });

        const onCheckAllChange = (e: any) => {
            Object.assign(state, {
                checkedList: e.target.checked ? [true, true, true] : [false, false, false],
                indeterminate: false,
            });
        };
        const onCheckNecessaryChange = () => {
            state.checkedList = [true, true, false];
        };
        watch(
            () => state.checkedList[0],
            val => {
                var num = 0;
                if (val) {
                    num = num + 1;
                }
                if (state.checkedList[1]) {
                    num = num + 1;
                }
                if (state.checkedList[2]) {
                    num = num + 1;
                }

                emit('regulationsChange', val && state.checkedList[1]);

                state.indeterminate = num == 1 || num == 2;
                state.checkAll = num === 3;
            },
        );
        watch(
            () => state.checkedList[1],
            val => {
                var num = 0;
                if (val) {
                    num = num + 1;
                }
                if (state.checkedList[0]) {
                    num = num + 1;
                }
                if (state.checkedList[2]) {
                    num = num + 1;
                }

                emit('regulationsChange', state.checkedList[0] && val);

                state.indeterminate = num == 1 || num == 2;
                state.checkAll = num === 3;
            },
        );
        watch(
            () => state.checkedList[2],
            val => {
                var num = 0;
                if (val) {
                    num = num + 1;
                }
                if (state.checkedList[1]) {
                    num = num + 1;
                }
                if (state.checkedList[0]) {
                    num = num + 1;
                }

                state.indeterminate = num == 1 || num == 2;
                state.checkAll = num === 3;
            },
        );

        return {
            ...toRefs(state),
            onCheckAllChange,
            onCheckNecessaryChange
        };
    }
});
</script>

<style>
    
</style>