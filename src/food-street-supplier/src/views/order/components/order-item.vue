<script setup lang="ts"></script>

<template>
  <div class="order-item !px-4">
    <div class="order-content !py-2 border-b border-gray-200">
      <div class="order-header !pb-2 flex justify-end">
        <div class="flex flex-1">
          <img
            class="w-8 h-8 rounded-full"
            src="https://picsum.photos/100"
            alt=""
          />
          <h1 class="font-semibold !px-2">黄记海鲜</h1>
        </div>
        <div>
          <i class="iconfont icon-jiantou2"></i>
        </div>
      </div>
      <div class="order-info flex">
        <div>
          <img
            class="w-28 h-28 rounded-md"
            src="https://picsum.photos/200"
            alt=""
          />
        </div>
        <div class="flex-1 !px-2">
          <div>
            <h1 class="text-xl">海鲜·龙虾</h1>
          </div>
          <div>
            <div class="bg-gray-100 rounded-md !px-1 w-fit text-sm">
              <i class="iconfont icon-task !pr-1"></i>
              <span class="text-gray-400">500g ±5g</span>
            </div>
          </div>
          <div class="flex justify-between items-center !pt-4">
            <div class="text-xl">
              <span>￥</span>
              <span class="font-inter">199.9</span>
            </div>
            <div>
              <span class="font-bold font-smiley">×1</span>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
