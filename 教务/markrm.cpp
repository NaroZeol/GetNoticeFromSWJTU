#include <iostream>
#include <string>
#include <sstream>

int main ()
{
    std::string context;
    std::string lines;
    
    while (std::getline(std::cin, lines)) {
        context += lines;
        context += "\n";
    }
    
    std::stringstream ss;

    bool flag = true;
    for (auto &c : context) {
        

        if (c == '<')
            flag = false;
        else if (c == '>')
            flag = true;
        else if (flag)
            ss << c;
    }

    std::cout << ss.str() << std::endl;
    return 0;
}