cd ./1.\ Main/
echo ">>>>> Creating Main Reasources..."
./tf.sh apply -auto-approve

cd ../2.\ Network/
echo ">>>>> Creating Network..."
./tf.sh apply -auto-approve

cd ../3.\ SQL_Server/
echo ">>>>> Creating SQL Server..."
./tf.sh apply -auto-approve

cd ../4.\ Deploy_APIs
echo ">>>>> Deploy APIs..."
./tf.sh apply -auto-approve

cd ../5.\ Deploy_Frontend_Container
echo ">>>>> Creating Frontend VM and Deploy..."
./tf.sh apply -auto-approve

# cd ../6.\ Output
# echo ">>>>> Creating Output..."
# ./tf.sh apply -auto-approve