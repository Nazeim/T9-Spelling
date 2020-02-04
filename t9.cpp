#include <string>
#include <vector>
#include <numeric>
#include <iostream>
#include <utility>

using namespace std;

string readLine() {
    string s;
    getline(cin, s);
    return s;
}

using token = pair<char, size_t>;

token encodeChar(char c) {
    static const vector<const string> n2s = { " ", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
    static const auto full = std::accumulate(begin(n2s), end(n2s), string{}, [](const string& res, const string& field) {
        return res + field + string(4 - field.size(), '_');
    });
    
    auto index = full.find(c);
    return { '0' + (index / 4), 1 + (index % 4) };
}


int main(int argc, const char * argv[]) {
    auto itemCount = stol(readLine()),
         counter = 0L;
    
    while (itemCount-- && cin.good()) {
        auto chars = readLine();
        auto lastChar = 'X';
        
        cout << "Case #" << ++counter << ": ";

        for (char c : chars) {
            auto tok = encodeChar(c);
            if (tok.first == lastChar)
                cout << ' ';
            lastChar = tok.first;

            cout << string(tok.second, tok.first);
        }
        cout << '\n';
    }
}
