<script setup lang="ts">
import { h, onBeforeUnmount, reactive } from "vue";
import { useRouter } from "vue-router";
import { Input, InputPassword, Button, Divider } from "ant-design-vue";
import { PhoneFilled, WechatOutlined } from "@ant-design/icons-vue";
import type { LoginRequest } from "@/types";
import { useAuthStore } from "@/stores";
import { useLoading } from "@frog/hooks";
import { message } from "ant-design-vue";

const router = useRouter();
const authStore = useAuthStore();
const loading = useLoading();

const loginForm = reactive<LoginRequest>({
  account: "19353464797",
  password: "123456",
});

const submitLogin = async () => {
  loading.startLoading();
  const res = await authStore.login(loginForm);
  if (res.isSucceed) {
    message.success("登录成功");
    router.push("/");
  }
};

onBeforeUnmount(() => {
  loading.stopLoading();
});
</script>

<template>
  <div
    class="login-container h-screen flex justify-center items-center overflow-x-hidden"
  >
    <div class="login shadow-lg rounded-md">
      <div class="login-content h-full !p-4 flex">
        <div class="login-img h-full w-1/2">
          <img
            class="h-full w-full object-cover"
            src="/images/login.jpeg"
            alt=""
          />
        </div>
        <div class="login-from flex-1">
          <div class="login-from-content !p-4">
            <div class="login-from-header h-14">
              <div class="from-header-logo flex">
                <img src="/vite.svg" alt="" />
                <h1 class="text-2xl font-mono font-semibold !px-2">
                  Food Street
                </h1>
              </div>
            </div>
            <div>
              <div>
                <h2 class="text-xl">登录您的账号</h2>
                <span class="text-sm text-gray-500">开始您的冒险吧！✨</span>
              </div>

              <div class="!mt-10">
                <div>
                  <div class="!my-2">
                    <Input
                      v-model:value="loginForm.account"
                      size="large"
                      placeholder="请输入您的账号"
                      :maxlength="11"
                      auto-size
                    />
                  </div>
                  <div class="!my-7">
                    <InputPassword
                      v-model:value="loginForm.password"
                      size="large"
                      placeholder="请输入您的密码"
                      :maxlength="32"
                    />
                  </div>
                  <Button @click="submitLogin" size="large" type="primary" block
                    >登录</Button
                  >
                </div>
              </div>
            </div>

            <div class="login-from-footer">
              <Divider class="!text-gray-500">Or</Divider>
              <div class="!gap-2 flex">
                <Button :icon="h(PhoneFilled)" size="large" block
                  >手机号</Button
                >
                <Button :icon="h(WechatOutlined)" size="large" block
                  >微信</Button
                >
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped>
.login-container {
  background: linear-gradient(
    to right,
    #ffecd2 0%,
    /* 起点（0%）为浅黄色 */ #fcb69f 50%,
    /* 中点（50%）为浅粉色 */ #a8c0ff 100% /* 终点（100%）为浅蓝色 */
  );
}

.login {
  width: 60em;
  height: 40em;
  background-color: var(--bg-primary);
  color: var(--text-primary);
}
</style>
