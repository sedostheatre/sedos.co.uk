echo "finding all files"
imagepaths=$(find . -name '*.jpg' -o -name '*.jpeg' -o -name '*.png')
counter=0
echo "iterating through files"
for imagepath in $imagepaths; do
    echo "checking $imagepath"
    filename=$(basename -- $imagepath)
    if ! grep -q -r --exclude-dir=".git" $filename .; then
        echo "removing $imagepath"
        git rm $imagepath
        counter=$((counter+1))
    fi
done

if [ "$counter" -eq "0" ]; then
    echo "No images were removed!"
else
    echo "Removed a total $counter images, w00t!"
fi