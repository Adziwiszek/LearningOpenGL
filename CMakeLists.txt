cmake_minimum_required(VERSION 3.10)

set(PROJECT_NAME LearningOpenGL)

project(${PROJECT_NAME})

set(CMAKE_CXX_STANDARD 20)
set(CMAKE_CXX_STANDARD_REQUIRED True)

file(GLOB_RECURSE SOURCES CONFIGURE_DEPENDS src/*.cpp)

find_package(OpenGL REQUIRED)
find_package(glm REQUIRED)

find_package(PkgConfig REQUIRED)
pkg_search_module(GLFW REQUIRED glfw3)

include_directories(${GLFW_INCLUDE_DIRS} include)
add_executable(${PROJECT_NAME} 
  ${SOURCES}
  src/glad.c
)

link_directories(${GLFW_LIBRARY_DIRS})
target_link_libraries(${PROJECT_NAME} 
  ${OPENGL_LIBRARIES} 
  ${GLFW_LIBRARIES}
)
