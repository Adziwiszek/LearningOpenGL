#include <glad/glad.h>
#include <GLFW/glfw3.h>
#include <iostream>

int main() {
  if(!glfwInit()) {
    std::cerr << "Failed to init glfw.\n";
    return -1;
  }
  glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 3);
  glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 3);
  glfwWindowHint(GLFW_OPENGL_PROFILE, GLFW_OPENGL_CORE_PROFILE);

  GLFWwindow* window = glfwCreateWindow(800, 600, "OpenGL Window", nullptr, nullptr);
  if(!window) {
    std::cerr << "Failed to create glfw window\n";
    glfwTerminate();
    return -1;
  }
  glfwMakeContextCurrent(window);

  if (!gladLoadGLLoader((GLADloadproc)glfwGetProcAddress)) {
      std::cout << "Failed to initialize GLAD" << std::endl;
      return -1;
  }

  while(!glfwWindowShouldClose(window)) {
    glClear(GL_COLOR_BUFFER_BIT);
    // TODO: renderuj coś

    glfwSwapBuffers(window);
    glfwPollEvents();
  }

  glfwDestroyWindow(window);
  glfwTerminate();
  return 0;
}

