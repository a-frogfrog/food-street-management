<script setup lang="ts">
import { ref } from "vue";
import { Container } from "@frog/components";
import { Button, Input, Select, Table } from "ant-design-vue";
import type { SelectProps } from "ant-design-vue";

const productOptions = ref<SelectProps["options"]>([
  {
    value: "jack",
    label: "Jack",
  },
  {
    value: "disabled",
    label: "Disabled",
    disabled: true,
  },
]);

const columns = [
  {
    title: "商品名称",
    dataIndex: "name",
    key: "name",
  },
  {
    title: "商品种类",
    dataIndex: "type",
    key: "type",
  },
  {
    title: "提供者",
    dataIndex: "provider",
    key: "provider",
  },
  {
    title: "商品状态",
    dataIndex: "status",
    key: "status",
  },
  {
    title: "操作",
    key: "action",
    slots: { customRender: "action" },
  },
];

const data = [
  {
    key: "1",
    name: "John Brown",
    type: "果蔬",
    provider: "张三",
    status: "上架",
  },
  {
    key: "2",
    name: "Jim Green",
    type: "果蔬",
    provider: "张三",
    status: "上架",
  },
  {
    key: "3",
    name: "Joe Black",
    type: "果蔬",
    provider: "张三",
    status: "上架",
  },
  {
    key: "4",
    name: "Jim Red",
    type: "果蔬",
    provider: "张三",
    status: "上架",
  },
  {
    key: "4",
    name: "Jim Red",
    type: "果蔬",
    provider: "张三",
    status: "上架",
  },
  {
    key: "4",
    name: "Jim Red",
    type: "果蔬",
    provider: "张三",
    status: "上架",
  },
];
</script>

<template>
  <Container>
    <div class="product-list">
      <header class="!pb-3">
        <div class="header-content !p-3 rounded-md">
          <h1 class="text-xl">商品列表</h1>
          <div class="header-filter">
            <div class="filter-item flex items-center !py-3">
              <div class="min-w-22">
                <span>商品种类:</span>
              </div>
              <div class="!px-3 flex-1 flex justify-end">
                <div class="gap-2 flex flex-1">
                  <Button type="primary">全部</Button>
                  <Button>果蔬</Button>
                  <Button>面食</Button>
                  <Button>其他</Button>
                </div>
                <div>
                  <Button type="text">更多</Button>
                </div>
              </div>
            </div>
            <div class="filter-item flex items-center !py-3">
              <div class="min-w-22">
                <span>提供者:</span>
              </div>
              <div class="!px-3 gap-2 flex flex-1">
                <Input class="!w-lg" placeholder="请输入提供者"></Input>
              </div>
            </div>
            <div class="filter-item flex items-center !py-3">
              <div class="min-w-22">
                <span>其他选项:</span>
              </div>
              <div class="!px-3 gap-4 flex flex-1">
                <div>
                  <span class="text-sm text-gray-500">商品状态：</span>
                  <Select class="!w-72" :options="productOptions"></Select>
                </div>
                <div>
                  <span class="text-sm text-gray-500">商品状态：</span>
                  <Select class="!w-72" :options="productOptions"></Select>
                </div>
              </div>
            </div>
          </div>
        </div>
      </header>
      <main class="!py-3">
        <div class="main-content !p-3 rounded-md">
          <Table :columns="columns" :data-source="data"></Table>
        </div>
      </main>
    </div>
  </Container>
</template>
<style scoped>
.header-content,
.main-content {
  background-color: var(--bg-primary);
}

.filter-item {
  border-bottom: 1px solid var(--border-color);
}

.filter-item:last-child {
  border-bottom: none;
}
</style>
