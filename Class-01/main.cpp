#include <glad/glad.h>
#include <GLFW/glfw3.h>

#include <iostream>


void processInput(GLFWwindow *window) {
    if (glfwGetKey(window, GLFW_KEY_ESCAPE) == GLFW_PRESS)
        glfwSetWindowShouldClose(window, true);
}


void framebuffer_size_callback(GLFWwindow* window, int width, int height) {
    glViewport(0, 0, width, height);
}


int main() {
    glfwInit();

    // 主版本号 (Major) 和次版本号 (Minor) 都设为 3
    glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 3);
    glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 3);

    // 告诉 GLFW 使用的是核心模式 (Core-profile)
    glfwWindowHint(GLFW_OPENGL_PROFILE, GLFW_OPENGL_CORE_PROFILE);

    GLFWwindow *window = glfwCreateWindow(800, 600, "Class01", NULL, NULL);
    if (window == NULL) {
        std::cout << "Failed to create GLFW window" << std::endl;
        glfwTerminate();
        return -1;
    }
    glfwMakeContextCurrent(window);

    if (!gladLoadGLLoader((GLADloadproc)glfwGetProcAddress)) {
        std::cout << "Failed to initialize GLAD" << std::endl;
        return -1;
    }

    glViewport(0, 0, 800, 600);
    glfwSetFramebufferSizeCallback(window, framebuffer_size_callback);

    /*
    `glfwWindowShouldClose` 函数在我们每次循环的开始前检查一次 `GLFW` 是否被要求退出, 如果是的话该函数返回 `true` 然后渲染循环便结束了, 之后为我们就可以关闭应用程序了
    `glfwPollEvents` 函数检查有没有触发什么事件 (比如键盘输入、鼠标移动等), 更新窗口状态, 并调用对应的回调函数 (可以通过回调方法手动设置) 
    `glfwSwapBuffers` 函数会交换颜色缓冲 (它是一个储存着 `GLFW` 窗口每一个像素颜色值的大缓冲) , 它在这一迭代中被用来绘制, 并且将会作为输出显示在屏幕上。
    */
    while (!glfwWindowShouldClose(window)) {
        // 输入
        processInput(window);

        // 渲染指令
        // 当调用 `glClear` 函数, 清除颜色缓冲之后, 整个颜色缓冲都会被填充为 `glClearColor` 里所设置的颜色
        glClearColor(0.2f, 0.3f, 0.3f, 1.0f);
        glClear(GL_COLOR_BUFFER_BIT);

        // 检查并调用事件, 交换缓冲
        glfwSwapBuffers(window);
        glfwPollEvents();
    }

    glfwTerminate();
    return 0;
}
