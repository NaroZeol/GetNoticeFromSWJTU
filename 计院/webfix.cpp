#include <iostream>
#include <string>
#include <sstream>

int main ()
{
    std::string context;
    std::string lines;
    
    while (std::getline(std::cin, lines)){
        context += lines;
        context += "\n";
    }
    if (context.empty())
        return 1;    
        
    std::stringstream ss;

    bool flag = false;
    for (auto it = context.begin(); it != context.end(); ++it) {
        if (*it == '.' && *(it + 1) == '.')
            flag = true;

        if (flag){
            while (true){
                ++it;
                if (*it != '\"'){
                    ss << *it;
                }
                else{
                    flag = false;
                    break;
                }
            }
            break;
        }

    }
    std::cout << "https://scai.swjtu.edu.cn";
    std::cout << ss.str() << std::endl;
    return 0;
}