<template>
    <a-form
      ref="formRef"
      name="custom-validation"
      :model="formState"
      :rules="rules"
      v-bind="layout"
      @finish="handleFinish"
      @validate="handleValidate"
      @finishFailed="handleFinishFailed"
    >
      <a-form-item has-feedback label="Username" name="username">
        <a-input v-model:value="formState.username" autocomplete="off" />
      </a-form-item>
      <a-form-item has-feedback label="Email" name="email">
        <a-input v-model:value="formState.email" autocomplete="off" />
      </a-form-item>
      <a-form-item has-feedback label="Password" name="pass">
        <a-input v-model:value="formState.pass" type="password" autocomplete="off" />
      </a-form-item>
      <a-form-item has-feedback label="Confirm" name="checkPass">
        <a-input v-model:value="formState.checkPass" type="password" autocomplete="off" />
      </a-form-item>
    </a-form>
  </template>
  <script lang="ts">
  import type { Rule } from 'ant-design-vue/es/form';
  import { defineComponent, reactive, ref } from 'vue';
  import type { FormInstance } from 'ant-design-vue';

  interface FormState {
    pass: string;
    checkPass: string;
    username: string;
    email: string;
  }

  interface FormStateBool {
    pass: boolean;
    checkPass: boolean;
    username: boolean;
    email: boolean;
  }

  export default defineComponent({
    setup(props, { emit }) {
      const formRef = ref<FormInstance>();
      const formState = reactive<FormState>({
        pass: '',
        checkPass: '',
        username: '',
        email: ''
      });
      const formStateBool = reactive<FormStateBool>({
        pass: false,
        checkPass: false,
        username: false,
        email: false
      });
      let checkLogin = async (_rule: Rule, value: string) => {
        if (!value) {
          formStateBool.username = false;
          return Promise.reject('Please input your username');
        }
        if (value.length < 8) {
          formStateBool.username = false;
          return Promise.reject('Please input more characters (at least 8)');
        } 
          formStateBool.username = true;
          return Promise.resolve();
      };
      let checkEmail = async (_rule: Rule, value: string) => {
        // eslint-disable-next-line
        const regularExpression = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        if (!value) {
          formStateBool.email = false;
          return Promise.reject('Please input your email');
        }
        if (!regularExpression.test(value.toLowerCase())) {
          formStateBool.email = false;
          return Promise.reject('Value does not match email pattern');
        } 
          formStateBool.email = true;
          return Promise.resolve();
      };
      let validatePass = async (_rule: Rule, value: string) => {
        if (value === '') {
          formStateBool.pass = false;
          return Promise.reject('Please input the password');
        } else {
          if (formState.checkPass !== '' && formRef && formRef.value) {
            formStateBool.pass = false;
            formRef.value.validateFields('checkPass');
          }
          formStateBool.pass = true;
          return Promise.resolve();
        }
      };
      let validatePass2 = async (_rule: Rule, value: string) => {
        if (value === '') {
          formStateBool.checkPass = false;
          return Promise.reject('Please input the password again');
        } else if (value !== formState.pass) {
          formStateBool.checkPass = false;
          return Promise.reject("Two inputs don't match!");
        } else {
          formStateBool.checkPass = true;
          return Promise.resolve();
        }
      };
  
      const rules: Record<string, Rule[]> = {
        pass: [{ required: true, validator: validatePass, trigger: 'change' }],
        checkPass: [{ required: true, validator: validatePass2, trigger: 'change' }],
        username: [{ required: true, validator: checkLogin, trigger: 'change' }],
        email: [{ required: true, validator: checkEmail, trigger: 'change' }],
      };
      const layout = {
        labelCol: { span: 4 },
        wrapperCol: { span: 14 },
      };
      const handleFinish = (values: FormState) => {
        console.log(values, formState);
      };
      const handleFinishFailed = (errors: any) => {
        console.log(errors);
      };
      const handleValidate = () => {
        emit('userformChange', formStateBool.checkPass && formStateBool.pass && formStateBool.username && formStateBool.email)
      };
      return {
        formState,
        formRef,
        rules,
        layout,
        handleFinishFailed,
        handleFinish,
        handleValidate,
      };
    },
  });
  </script>