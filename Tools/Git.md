# Git

##git playground
[http://onlywei.github.io/explain-git-with-d3/#freeplay](http://onlywei.github.io/explain-git-with-d3/#freeplay)

##Basic git commands  

**Info: status ; branch ; log ; tag**  
Info: remote -v ; branch -r ; remote show {bname}  
Ignore: create a file .gitignore [https://github.com/github/gitignore](https://github.com/github/gitignore)  
**Stage/all: add {fname} ; add .**  
**Commit: commit ; commit –m “my comment”**  
Restore Work from stage: checkout -- {fname}  
Restore Work from Commit: checkout HEAD -- {fname}  
Undo Stage -> Work: reset {fname/.}    
**Undo Commit -> Work: reset --hard HEAD^**   
Undo Commit -> Stage: reset --soft HEAD^    
Stash: stash ; stash pop ; stash drop  ; stash list  
**Branch Add: branch {bname}**    
**Branch Switch: checkout {bname/.}**  
**Branch Add & Switch: checkout -b {tbname} {fbname}**  
**Branch Merge: merge {frombname}**  
**Branch Del: branch –d {bname}**  
Rename: mv {sfname} {dfname}  
**Del: rm {fname}**  
Diff Commit: diff HEAD ; diff HEAD^ //stage & unstage  
Skip Stage & Commit: commit -all -m "my comment"  
AppendCommit: commit --amend -m "my comment"  
**Clone: clone {url}**  
Add: remote add {rname} {url} // origin http://...    
Push 1st: push -u {rname} {lbname} //-u remember params  
Push/Pull: push ; pull // i.e. fetch + merge {lbname}  
Fetch: fetch // into lrepo lbname  
Tag: tag -a vx.x.x.x -m "ver. comment" ;  push --tags  
Color: config --global color.ui true  
Graph: log --oneline --graph  
Range: log --since=1.month.ago --until=1.day.ago  
VIM: ‘i’ ; [ESC] ; :x ; :q  

[Git Reset Demystified](https://git-scm.com/blog)

[Git Visualize](http://marklodato.github.io/visual-git-guide/index-en.html)

Both commit nodes B and C are parents of commit node A (HEAD). Parent commits are ordered left-to-right.

```
G   H   I   J
 \ /     \ /
  D   E   F
   \  |  / \
    \ | /   |
     \|/    |
      B     C
       \   /
        \ /
         A (HEAD)
         
A =      = A^0
B = A^   = A^1     = A~1
C = A^2  = A^2
D = A^^  = A^1^1   = A~2
E = B^2  = A^^2
F = B^3  = A^^3
G = A^^^ = A^1^1^1 = A~3
H = D^2  = B^^2    = A^^^2  = A~2^2
I = F^   = B^3^    = A^^3^
J = F^2  = B^3^2   = A^^3^2
```

##Syncing a fork

1. Fork a repo [github]
2. Clone the forked repo [local]
3. [Create a 'upstream' remote that your fork is originated from](https://help.github.com/articles/configuring-a-remote-for-a-fork/) [local]
4. [Pull upstream repo](https://help.github.com/articles/syncing-a-fork/) [local]
  * In SourceTree, you can right-click the 'upstream/master' and choose 'Pull upstream/master to master
  * p.s. a 'Pull' is a fetch + merge
5. Push master to forked repo. In SourceTree, you right-click the master and choose 'Push to origin/master' [local]


##Git WorkFlow with collaboration

1. [GitFlow Workflow](https://www.atlassian.com/git/tutorials/comparing-workflows/gitflow-workflow)
 * Branch Names
  * master
  * develop
  * feature
  * release
  * hotfix
2. [Fork Workflow](https://www.atlassian.com/git/tutorials/comparing-workflows/forking-workflow)

##Git Flow

![](http://nvie.com/img/git-model@2x.png)

###GitFlow CLI

[http://danielkummer.github.io/git-flow-cheatsheet](http://danielkummer.github.io/git-flow-cheatsheet)

## Git-Real Levels
[Videos:](https://onedrive.live.com/?cid=3933FEFFB336CF0E&id=3933feffb336cf0e%2121122&authkey=%21AFfC-QjXUeqZzlw)  

1. [Basic](https://github.com/vincenthome/Git/blob/master/git-real/git_real-level-1.pdf)
2. [Staging, Commit & Remote - Cool](https://github.com/vincenthome/Git/blob/master/git-real/git_real-level-2.pdf)
3. [Clone & Branch - Cool](https://github.com/vincenthome/Git/blob/master/git-real/git_real-level-3.pdf)
4. [Collobration - Cool](https://github.com/vincenthome/Git/blob/master/git-real/git_real-level-4.pdf)
5. [Remote Branch & Tag](https://github.com/vincenthome/Git/blob/master/git-real/git_real-level-5.pdf)
6. [Rebase](https://github.com/vincenthome/Git/blob/master/git-real/git_real-level-6.pdf)
7. [History & Configuration](https://github.com/vincenthome/Git/blob/master/git-real/git_real-level-7.pdf)

##GitHub Git CheatSheet:
[https://training.github.com/kit/downloads/github-git-cheat-sheet.pdf](https://training.github.com/kit/downloads/github-git-cheat-sheet.pdf)  


https://try.github.io/levels/1/challenges/1  
http://git-scm.com/docs/git-commit  
http://git-scm.com/blog/2011/07/11/reset.html