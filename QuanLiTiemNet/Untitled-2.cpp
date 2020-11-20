#include <iostream>
#include <string>
using namespace std;
int main(){
    string s;
    cin >> s;
    int i,d;
    if (!(s == "0")){
        for (i = 0; i <= s.length()-1;i++){
            if(s[i] < s[i+1]){
                s.erase(i,1);
                d = 1;
                break;
            }
        }
        if (d == 0){
            s.erase(s.length()-1,1);
        }
    }
    cout << s;
}
