# ShaderExercise
总结下吧

这个库太乱了，换一个 [TWO](https://github.com/oneputatoT/ShaderTwo)

《Unity Shader 入门精要》看完了，但是感觉也就是个60%左右，我之后打算再重温一遍，尽量把这个值拉到80%，哈哈哈哈
不过先继续学习，我看看我自学的和专业的在观点上有什么不同，继续纠正自学所带的副作用，努力提升成半专业模式

连连看虽好，但要丢进垃圾桶里哦

![图片](https://user-images.githubusercontent.com/50166070/159422407-f43d457b-81f6-4664-93cf-10feeea81481.png)


# 描边的五种实现方法

引用这位知乎大佬：https://zhuanlan.zhihu.com/p/410710318

然后模板测试：https://blog.csdn.net/aa20274270/article/details/48786051

其中后处理的边缘检测，我更喜欢看做信号中给图像一个高通信号，毕竟后处理就是图像处理嘛，当我们物体颜色发生突变时候，就会产生一个高频的信号，抓取这个信号，就可以完成边缘的检测了，但是时域上相乘就是频域上卷积，道理一样

SDF：https://zhuanlan.zhihu.com/p/26217154

感觉原理很简单阿，就想象每个像素点都是一个圆，然后里就是负，圆上就是零，外就是正

![图片](https://user-images.githubusercontent.com/50166070/159486918-1d06ba0e-70ce-4631-b06a-3d98951b326a.png)

