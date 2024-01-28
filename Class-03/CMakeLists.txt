cmake_minimum_required(VERSION 3.10)

project(main)

add_executable(main main.cpp)


find_package(glad CONFIG REQUIRED)
target_link_libraries(main PRIVATE glad::glad)
if(glad_FOUND)
    message("glad found")
endif()


find_package(glfw3 CONFIG REQUIRED)
target_link_libraries(main PRIVATE glfw)
if(glfw3_FOUND)
    message("glfw3 found")
endif()
