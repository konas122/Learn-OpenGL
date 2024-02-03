cmake_minimum_required(VERSION 3.10)

project(main)

get_filename_component(PARENT_DIR "${CMAKE_CURRENT_SOURCE_DIR}" DIRECTORY)
include_directories(${PARENT_DIR}/include)

file(COPY ${CMAKE_SOURCE_DIR}/model.vs DESTINATION ${CMAKE_BINARY_DIR}/Debug)
file(COPY ${CMAKE_SOURCE_DIR}/model.fs DESTINATION ${CMAKE_BINARY_DIR}/Debug)
file(COPY ${PARENT_DIR}/resources/nanosuit DESTINATION ${CMAKE_BINARY_DIR}/Debug)


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

find_package(glm CONFIG REQUIRED)
target_link_libraries(main PRIVATE glm::glm)
if(glm_FOUND)
    message("glm found")
endif()

find_package(assimp CONFIG REQUIRED)
target_link_libraries(main PRIVATE assimp::assimp)
if(assimp_FOUND)
    message("assimp found")
endif()
